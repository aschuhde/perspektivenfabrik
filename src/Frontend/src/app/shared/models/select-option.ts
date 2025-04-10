export class SelectOption{
    entityId: string | null = null;
    value: string = ""
    text: string = ""

    constructor(value: string, text: string | null = null, entityId: string | null = null){
        this.value = value;
        this.text = text === null ? value : text;
        this.entityId = entityId;
    }
}