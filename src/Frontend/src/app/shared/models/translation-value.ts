import {Language} from "../../core/types/general-types";
import {
    DomainDataTypesTranslationValue
} from "../../server/model/domainDataTypesTranslationValue";
import {ObjectCreator} from "../tools/object-creator";

export class TranslationValue {
    constructor(language: Language, value: string) {
        this.language = language;
        this.value = value;
    }
    updateValue(value: string) {
        this.value = value;
    }
    static arrayFromApiTranslationValues(projectTitleTranslations: DomainDataTypesTranslationValue[]) {
        return projectTitleTranslations.map(x => TranslationValue.fromApiTranslationValue(x));
    }
    static fromApiTranslationValue(projectTitleTranslation: DomainDataTypesTranslationValue) {
        return new TranslationValue(projectTitleTranslation?.languageCode === "it" ? "it" : "de", projectTitleTranslation?.value ?? "");
    }
    static toApiTranslationValue(translationValue: TranslationValue) {
        return ObjectCreator.Create<DomainDataTypesTranslationValue>({
            languageCode: translationValue.language,
            value: translationValue.value
        });
    }
    static toApiTranslationValues(translationValues: TranslationValue[]) {
        return translationValues.map(x => TranslationValue.toApiTranslationValue(x));       
    }

    static getTranslationIfExist(value: string, translations: TranslationValue[], language: Language) {
        const translation = translations.find(x => x.language == language);
        if(translation?.value){
            return translation.value;
        }
        return value;
    }
    language: Language = "de";
    value: string = "";
}