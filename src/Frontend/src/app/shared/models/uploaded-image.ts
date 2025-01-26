export class UploadedImage{
    readonly file: File
    readonly src: string
    constructor(file: File){
        this.file = file;
        this.src = URL.createObjectURL(file);
    }
}