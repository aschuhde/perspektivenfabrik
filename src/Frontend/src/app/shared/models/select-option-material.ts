import { SelectOption } from "./select-option";

export class SelectOptionMaterial extends SelectOption{
    amount: string
    description: string

    constructor(value: string, text: string | null = null, amount: string | null = null, description: string | null = null){
        super(value, text)
        this.amount = amount ?? "";
        this.description = description ?? "";
    }
}