export class MessageDialogData{
    title: string = ""
    message: string = ""
    buttonText: string = "Ok"

    constructor(init?: Partial<MessageDialogData>){
        Object.assign(this, init);
    }
}