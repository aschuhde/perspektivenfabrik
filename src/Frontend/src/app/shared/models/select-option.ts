import { TranslationValue } from "./translation-value";

export class SelectOption{
    entityId: string | null = null;
    value: string = ""
    valueTranslations: TranslationValue[] = [];
    text: string = ""
    textTranslations: TranslationValue[] = [];
    constructor(value: string, text: string | null = null, entityId: string | null = null, valueTranslations: TranslationValue[] = [], textTranslations: TranslationValue[] = []){
        this.value = value;
        this.text = text === null ? value : text;
        this.entityId = entityId;
        this.valueTranslations = valueTranslations;
        this.textTranslations = textTranslations;
    }
}