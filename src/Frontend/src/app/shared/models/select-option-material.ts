import { SelectOption } from "./select-option";

export class SelectOptionMaterial extends SelectOption{
    amount: string
    description: string

    constructor(value: string, text: string | null = null, amount: string | null = null, description: string | null = null, entityId : string | null = null){
        super(value, text, entityId);
        this.amount = amount ?? "";
        this.description = description ?? "";
    }
}