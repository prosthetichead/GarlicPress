export class BlazorFabric {
    static canvas = null;
    static dotnetMediaGenerationEditor = null;
    static originalWidth = 0;
    static originalHeight = 0;

    static createCanvas = (canvasId, dotnetHelper) => {
        if (BlazorFabric.canvas === null) {
            BlazorFabric.canvas = new fabric.Canvas(canvasId, { preserveObjectStacking: true });
        }

        this.dotnetMediaGenerationEditor = dotnetHelper;

        BlazorFabric.originalWidth = BlazorFabric.canvas.width;
        BlazorFabric.originalHeight = BlazorFabric.canvas.height;

        BlazorFabric.resizeCanvas();

        BlazorFabric.canvas.on('object:modified', options => BlazorFabric.handleImageEvent(options.target, 'NotifyImageLocationUpdated'));
        BlazorFabric.canvas.on('selection:updated', options => BlazorFabric.handleImageEvent(options.selected[0], 'NotifyImageSelected'));
        BlazorFabric.canvas.on('selection:created', options => BlazorFabric.handleImageEvent(options.selected[0], 'NotifyImageSelected'));


        BlazorFabric.canvas.on('selection:cleared', function () {
            BlazorFabric.dotnetMediaGenerationEditor.invokeMethodAsync('NotifyImageUnselected')
                .catch(error => console.error(error));
        });
    };

    static handleImageEvent(obj, methodName) {
        if (obj instanceof fabric.Image && obj.model != undefined) {
            obj.model.x = Math.round(obj.left);
            obj.model.y = Math.round(obj.top);
            obj.model.angle = Math.round(obj.angle);
            obj.model.resizePercent = Math.round(obj.scaleX * 100);
            obj.model.order = BlazorFabric.canvas._objects.filter(o => o.selectable).indexOf(obj);


            const imageDetails = JSON.stringify({
                id: obj.id,
                model: obj.model,
                imageUrl: obj.imgUrl,
                left: Math.round(obj.left),
                top: Math.round(obj.top),
                angle: Math.round(obj.angle),
                scale: Math.round(obj.scaleX * 100),
                drawOrder: BlazorFabric.canvas._objects.filter(o => o.selectable).indexOf(obj)
            });

            BlazorFabric.dotnetMediaGenerationEditor.invokeMethodAsync(methodName, imageDetails)
                .catch(error => console.error(error));
        }
    }

    static clearCanvas = () => {
        if (BlazorFabric.canvas != null) {
            try {
                BlazorFabric.canvas.clear();
                BlazorFabric.canvas.off('object:added');
            } catch (e) {

            }
        }
    };

    static addBackgroundImage = (imageUrl) => {
        if (BlazorFabric.canvas != null) {
            fabric.Image.fromURL(imageUrl, function (img) {
                img.set({
                    left: 0,
                    top: 0,
                    angle: 0,
                    selectable: false
                });
                img.moveTo(0);
                BlazorFabric.canvas.add(img);
                BlazorFabric.canvas.sendToBack(img);
            }.bind(BlazorFabric));
        }
    };

    static addStaticImage = (imageUrl, left, top) => {
        if (BlazorFabric.canvas != null) {
            fabric.Image.fromURL(imageUrl, function (img) {
                img.set({
                    left: left,
                    top: top,
                    angle: 0,
                    selectable: false,
                    drawOrder: 100,
                    originX: 'center',
                    originY: 'center'
                });
                BlazorFabric.canvas.add(img);
                BlazorFabric.canvas.on('object:added', function (options) {
                    this.canvas.bringToFront(img);
                }.bind(this));
            }.bind(BlazorFabric));
        }
    };

    static addImage = (imageUrl, id, model) => {
        if (BlazorFabric.canvas != null) {
            fabric.Image.fromURL(imageUrl, (img) => {
                img.set({
                    imgUrl: imageUrl,
                    id: id,
                    model: model,
                    left: model.x,
                    top: model.y,
                    scaleX: (model.resizePercent / 100),
                    scaleY: (model.resizePercent / 100),
                    angle: model.angle,
                    selectable: true,
                    uniformScaling: false,
                    drawOrder: model.order
                });

                img.setControlsVisibility({
                    mt: false,
                    mb: false,
                    ml: false,
                    mr: false
                });

                if (typeof model.order !== "undefined") {
                    // Find the position of the first object with a greater or equal draw order
                    let position = BlazorFabric.canvas.getObjects().filter(o => o.selectable).findIndex(obj => obj.drawOrder >= model.order);

                    if (position === -1) {
                        BlazorFabric.canvas.add(img);
                    } else {
                        BlazorFabric.canvas.insertAt(img, position + 1);
                    }
                } else {
                    BlazorFabric.canvas.add(img);
                }

                BlazorFabric.canvas.renderAll();
            });
        }
    };


    static addText = (content, left = 0, top = 0, textColor = 'black', fontFamily = 'Arial', fontSize = 28, textAlign = "left", selectedRow = 4, selectedColor = "white") => {
        if (BlazorFabric.canvas) {
            if (textAlign === 'center') {
                left = BlazorFabric.originalWidth / 2;
            }
            if (textAlign === 'right') {
                left = BlazorFabric.originalWidth - left;
            }

            const text = new fabric.IText(content, {
                left: left,
                top: top,
                fill: textColor,
                fontFamily: fontFamily,
                selectable: false,
                fontSize: fontSize,
                textAlign: textAlign,
                originX: 'center',
                originY: 'center',
                lineHeight: 1.35,
                evented: false
            });

            text.set({ originX: textAlign });

            if (selectedRow > 0 && selectedRow <= text._textLines.length) {
                if (!text.styles[selectedRow - 1]) {
                    text.styles[selectedRow - 1] = {};
                }
                // Modify the styles property to change color for each character in the specified row
                for (let i = 0; i < text._textLines[selectedRow - 1].length; i++) {
                    text.styles[selectedRow - 1][i] = { fill: selectedColor };
                }
            }

            BlazorFabric.canvas.on('object:added', function (options) {
                this.canvas.bringToFront(text);
            }.bind(this));

            BlazorFabric.canvas.add(text);
        }
    };


    static updateImage = function (imageId, model, imgUrl) {
        if (BlazorFabric.canvas != null) {
            // Find the image with the provided ID
            const img = BlazorFabric.canvas._objects.find(obj => obj.id === imageId);

            if (img) {
                img.set({
                    left: model.x,
                    top: model.y,
                    scaleX: (model.resizePercent / 100),
                    scaleY: (model.resizePercent / 100),
                    angle: model.angle,
                    drawOrder: model.order
                });

                // If imgUrl is not null, update the image's src
                if (imgUrl) {
                    fabric.Image.fromURL(imgUrl, function (newImg) {
                        img.setElement(newImg.getElement());
                        BlazorFabric.canvas.renderAll();
                    });
                } else {
                    BlazorFabric.canvas.renderAll();
                }
            }
        }
    };

    static selectObject(imageId) {
        if (BlazorFabric.canvas != null) {
            const img = BlazorFabric.canvas._objects.find(obj => obj.id === imageId);

            if (img) {
                BlazorFabric.canvas.setActiveObject(img);
                BlazorFabric.canvas.renderAll();
            }
        }
    }

    static deleteSelectedObject(notifyDotnet = true) {
        const activeObject = BlazorFabric.canvas.getActiveObject();
        if (activeObject) {
            if (notifyDotnet) {
                BlazorFabric.dotnetMediaGenerationEditor.invokeMethodAsync('NotifyImageDeleted', activeObject.id)
                    .catch(error => console.error(error));
            }

            BlazorFabric.canvas.remove(activeObject);
            BlazorFabric.canvas.requestRenderAll();
        }
    }

    static deleteObject(imageId) {
        if (BlazorFabric.canvas != null) {
            const img = BlazorFabric.canvas._objects.find(obj => obj.id === imageId);

            if (img) {
                BlazorFabric.canvas.remove(img);
                BlazorFabric.canvas.requestRenderAll();
            }
        }
    }

    static moveObjectForward() {
        const activeObject = BlazorFabric.canvas.getActiveObject();
        if (activeObject instanceof fabric.Image) {
            activeObject.model.order = BlazorFabric.canvas._objects.indexOf(activeObject) - 1;
            activeObject.set({
                drawOrder: BlazorFabric.canvas._objects.indexOf(activeObject)
            });

            BlazorFabric.canvas.bringForward(activeObject);
            BlazorFabric.canvas.renderAll();

            BlazorFabric.notifyAllImages();
        }
    }

    static moveObjectBackward() {
        const activeObject = BlazorFabric.canvas.getActiveObject();
        if (activeObject instanceof fabric.Image) {
            activeObject.model.order = BlazorFabric.canvas._objects.indexOf(activeObject) - 1;
            activeObject.set({
                drawOrder: BlazorFabric.canvas._objects.indexOf(activeObject)
            });
            BlazorFabric.canvas.sendBackwards(activeObject);
            BlazorFabric.canvas.renderAll();

            BlazorFabric.notifyAllImages();
        }
    }

    static notifyAllImages() {
        const objects = BlazorFabric.canvas._objects;
        for (let i = 0; i < objects.length; i++) {
            const obj = objects[i];
            if (obj instanceof fabric.Image) {
                BlazorFabric.handleImageEvent(obj, 'NotifyImageLocationUpdated');
            }
        }
    }

    //move object one pixel in direction
    static moveObject(direction) {
        const activeObject = BlazorFabric.canvas.getActiveObject();
        if (activeObject instanceof fabric.Image) {
            switch (direction) {
                case "up":
                    activeObject.set({
                        top: activeObject.top - 1
                    });
                    break;
                case "down":
                    activeObject.set({
                        top: activeObject.top + 1
                    });
                    break;
                case "left":
                    activeObject.set({
                        left: activeObject.left - 1
                    });
                    break;
                case "right":
                    activeObject.set({
                        left: activeObject.left + 1
                    });
                    break;
            }
            BlazorFabric.canvas.renderAll();
            BlazorFabric.handleImageEvent(activeObject, 'NotifyImageLocationUpdated');
        }
    }

    static exportCanvasAsPNG() {
        return BlazorFabric.canvas.toDataURL('png');
    }

    static resizeCanvas() {
        if (BlazorFabric.canvas != null) {
            // Get the parent container dimensions
            const container = BlazorFabric.canvas.wrapperEl.parentNode;
            const containerWidth = container.clientWidth;
            const containerHeight = container.clientHeight;

            // Get the padding of the parent container
            const style = window.getComputedStyle(container);
            const paddingTop = parseFloat(style.paddingTop);
            const paddingBottom = parseFloat(style.paddingBottom);
            const paddingLeft = parseFloat(style.paddingLeft);
            const paddingRight = parseFloat(style.paddingRight);

            // Adjust the available width and height based on the padding
            const availableWidth = containerWidth - paddingLeft - paddingRight;
            const availableHeight = containerHeight - paddingTop - paddingBottom;

            const scaleX = availableWidth / BlazorFabric.originalWidth;
            const scaleY = availableHeight / BlazorFabric.originalHeight;

            // Use the smallest scale ratio to ensure the canvas content fits both horizontally and vertically
            const scale = Math.min(scaleX, scaleY);

            // If the scale is greater than 1, reset it to 1 to prevent upscaling
            const zoomFactor = (scale > 1) ? 1 : scale;

            // Compute the new width and height while preserving the aspect ratio
            const newCanvasWidth = BlazorFabric.originalWidth * zoomFactor;
            const newCanvasHeight = BlazorFabric.originalHeight * zoomFactor;

            // Update canvas dimensions
            BlazorFabric.canvas.setWidth(newCanvasWidth);
            BlazorFabric.canvas.setHeight(newCanvasHeight);

            BlazorFabric.canvas.setZoom(zoomFactor);
            BlazorFabric.canvas.calcOffset(); // Refresh canvas offsets
            BlazorFabric.canvas.renderAll(); // Re-render the canvas
        }
    }
}

window.BlazorFabric = BlazorFabric;

window.addEventListener('keydown', function (e) {
    // Inkscape's shortcuts for moving objects
    if (e.key === "PageUp") {
        BlazorFabric.moveObjectForward();
    } else if (e.key === "PageDown") {
        BlazorFabric.moveObjectBackward();
    }

    // Photoshop's shortcuts for moving objects
    if (e.ctrlKey && e.key === "]") {
        BlazorFabric.moveObjectForward();
    } else if (e.ctrlKey && e.key === "[") {
        BlazorFabric.moveObjectBackward();
    }

    // 'Delete' object
    if (e.key === "Delete") {
        BlazorFabric.deleteSelectedObject();
    }

    // arrow keys for moving selected object
    if (e.key === "ArrowUp") {
        BlazorFabric.moveObject("up");
    }
    if (e.key === "ArrowDown") {
        BlazorFabric.moveObject("down");
    }
    if (e.key === "ArrowLeft") {
        BlazorFabric.moveObject("left");
    }
    if (e.key === "ArrowRight") {
        BlazorFabric.moveObject("right");
    }
});

window.addEventListener('resize', function () {
    BlazorFabric.resizeCanvas();
});
