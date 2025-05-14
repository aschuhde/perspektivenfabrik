import { SelectOption } from "./select-option";
import {TranslationValue} from "./translation-value";

export class SelectOptionMaterial extends SelectOption{
    amount: string
    description: string
    amountTranslations: TranslationValue[]
    descriptionTranslations: TranslationValue[]

    constructor(init: Partial<SelectOptionMaterial>){
        super(init.value ?? "", init.text, init.entityId, init.valueTranslations, init.textTranslations);
        this.amount = init.amount ?? "";
        this.description = init.description ?? "";
        this.amountTranslations = init.amountTranslations ?? [];
        this.descriptionTranslations = init.descriptionTranslations ?? [];
    }
}