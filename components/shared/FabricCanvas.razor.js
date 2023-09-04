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
        if (obj instanceof fabric.Image) {

            obj.model.x = Math.round(obj.left);
            obj.model.y = Math.round(obj.top);
            obj.model.angle = Math.round(obj.angle);
            obj.model.resizePercent = Math.round(obj.scaleX * 100);
            obj.model.order = BlazorFabric.canvas._objects.indexOf(obj);


            const imageDetails = JSON.stringify({
                id: obj.id,
                model: obj.model,
                imageUrl: obj.imgUrl,
                left: Math.round(obj.left),
                top: Math.round(obj.top),
                angle: Math.round(obj.angle),
                scale: Math.round(obj.scaleX * 100),
                drawOrder: BlazorFabric.canvas._objects.indexOf(obj)
            });

            BlazorFabric.dotnetMediaGenerationEditor.invokeMethodAsync(methodName, imageDetails)
                .catch(error => console.error(error));
        }
    }

    static clearCanvas = () => {
        if (BlazorFabric.canvas != null) {
            BlazorFabric.canvas.clear();
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
                    let position = BlazorFabric.canvas.getObjects().findIndex(obj => obj.drawOrder >= model.order);

                    if (position === -1) {
                        BlazorFabric.canvas.add(img);
                    } else {
                        BlazorFabric.canvas.insertAt(img, position);
                    }
                } else {
                    BlazorFabric.canvas.add(img);
                }

                BlazorFabric.canvas.renderAll();
            });
        }
    };


    static addText = (content, left = 0, top = 0, textColor = 'black', fontFamily = 'Arial', fontSize = 28, textAlign = "left") => {
        if (BlazorFabric.canvas) {
            const text = new fabric.Text(content, {
                left: left,
                top: top,
                fill: textColor,
                fontFamily: fontFamily,
                selectable: false,
                fontSize: fontSize,
                textAlign: textAlign,
            });

            BlazorFabric.canvas.off('object:added').on('object:added', function (options) {
                var obj = options.target;
                if (obj instanceof fabric.Image) {
                    this.canvas.bringToFront(text);
                }
            }.bind(this));

            this.canvas.add(text);
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

    static moveObjectForward() {
        const activeObject = BlazorFabric.canvas.getActiveObject();
        if (activeObject instanceof fabric.Image) {
            activeObject.model.order = BlazorFabric.canvas._objects.indexOf(activeObject) - 1;
            activeObject.set({
                drawOrder: BlazorFabric.canvas._objects.indexOf(activeObject)
            });

            BlazorFabric.canvas.bringForward(activeObject);
            BlazorFabric.canvas.renderAll();

            BlazorFabric.handleImageEvent(activeObject, 'NotifyImageLocationUpdated');
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
});

window.addEventListener('resize', function () {
    BlazorFabric.resizeCanvas();
});
