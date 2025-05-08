export class MessageDialogData{
    title: string = ""
    message: string = ""
    buttonText: string = "Ok"
    isHtmlMessage: boolean = false

    constructor(init?: Partial<MessageDialogData>){
        Object.assign(this, init);
    }
}