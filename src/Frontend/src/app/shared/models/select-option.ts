export class SelectOption{
    value: string = ""
    text: string = ""

    constructor(value: string, text: string | null = null){
        this.value = value;
        this.text = text === null ? value : text;
    }
}