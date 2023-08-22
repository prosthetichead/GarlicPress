export class BlazorFabric {
    static canvas = null;
    static dotnetHelper = null;

    static createCanvas = (canvasId, dotnetHelper) => {
        if (BlazorFabric.canvas === null) {
            BlazorFabric.canvas = new fabric.Canvas(canvasId, { preserveObjectStacking: true });
        }

        this.dotnetHelper = dotnetHelper;
    };

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
                    scaleX: 1,
                    scaleY: 1,
                    selectable: false
                });
                BlazorFabric.canvas.add(img);
                BlazorFabric.canvas.sendToBack(img);
            }.bind(BlazorFabric));
        }
    };

    static addImage = (imageUrl, id, left = 0, top = 0, scale = 1, angle = 0) => {
        if (BlazorFabric.canvas != null) {
            fabric.Image.fromURL(imageUrl, (img) => {
                img.set({
                    id: id,
                    left: left,
                    top: top,
                    scaleX: scale,
                    scaleY: scale,
                    angle: angle,
                    selectable: true,
                    uniformScaling: false
                });
                img.setControlsVisibility({
                    mt: false,
                    mb: false,
                    ml: false,
                    mr: false
                })
                BlazorFabric.canvas.add(img);
                BlazorFabric.canvas.renderAll();
            });
        }
    };

    static addText = (content, left = 0, top = 0, textColor = 'black', activeTextColor = 'red', fontFamily = 'Arial', fontSize = 28, textAlign = "left") => {
        if (this.canvas) {
            const text = new fabric.Text(content, {
                left: left,
                top: top,
                fill: textColor,
                fontFamily: fontFamily,
                selectable: false,
                fontSize: fontSize,
                textAlign: textAlign,
                // other properties as required...
            });

            // If you want to change the text color when the item is active (selected),
            // you can add an event listener to the 'selected' event.
            text.on('selected', function () {
                text.set('fill', activeTextColor);
                this.canvas.renderAll();
            });

            // Similarly, you can revert the color when the object is deselected.
            text.on('deselected', function () {
                text.set('fill', textColor);
                this.canvas.renderAll();
            });

            this.canvas.add(text);
        }
    };


    static deleteSelectedObject() {
        const activeObject = BlazorFabric.canvas.getActiveObject();
        if (activeObject) {

            BlazorFabric.dotnetHelper.invokeMethodAsync('NotifyImageDeleted', activeObject.id)
                .catch(error => console.error(error));

            BlazorFabric.canvas.remove(activeObject);
            BlazorFabric.canvas.requestRenderAll();
        }
    }

    // This method will be called from C# to set up the event listener
    static setupImageLocationUpdatedCallback = () => {
        if (this.canvas != null) {
            this.canvas.on('object:modified', function (options) {
                const obj = options.target;

                if (obj instanceof fabric.Image) {
                    const imageDetails = JSON.stringify({
                        id: obj.id,
                        left: Math.round(obj.left),
                        top: Math.round(obj.top),
                        angle: Math.round(obj.angle),
                        scale: Math.round(obj.scaleX * 100)
                    });

                    // Call the C# method
                    BlazorFabric.dotnetHelper.invokeMethodAsync('NotifyImageLocationUpdated', imageDetails)
                        .catch(error => console.error(error));
                }
            });
        }
    };
}

window.BlazorFabric = BlazorFabric;

window.addEventListener('keydown', function (e) {
    // Check for the Delete key
    if (e.key === "Delete") {
        BlazorFabric.deleteSelectedObject();
    }
});