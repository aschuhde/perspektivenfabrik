import { Component, inject, input, model } from '@angular/core';
import { TranslationValue } from '../../models/translation-value';
import {MatFormField, MatInput, MatLabel } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { LanguageService } from '../../../core/services/language-service.service';
import { Language } from '../../../core/types/general-types';

@Component({
  selector: 'app-mat-input-translations',
  imports: [MatInput, FormsModule, MatLabel, MatFormField],
  templateUrl: './mat-input-translations.component.html',
  styleUrl: './mat-input-translations.component.scss'
})
export class MatInputTranslationsComponent {
  class = input("")
  label = input("")
  withoutBorderRadius = input(false)
  value = model("")
  translations = model<TranslationValue[]>([])
  languageService = inject(LanguageService)
  selectedLanguage = model<Language>(this.languageService.currentLanguageCode)
  
  
  private isChangingLanguage = false;
  ngOnInit(){
    this.value.subscribe(() => {
      if(this.isChangingLanguage) return;
      
      this.updateValue(this.selectedLanguage(), this.value());
    });
    this.selectedLanguage.subscribe((value) => {
      if(this.isChangingLanguage) return;
      
      this.changeLanguage(value);
    });
  }
  ngAfterViewInit(){
    this.isChangingLanguage = true;
    this.value.set(TranslationValue.getTranslationIfExist(this.value(), this.translations(), this.selectedLanguage()));
    this.isChangingLanguage = false;
  }
  get italianIsActive(){
    return this.selectedLanguage() === "it";
  }
  get germanIsActive(){
    return !this.italianIsActive;
  }
  
  selectItalian(){
    this.changeLanguage("it");
  }
  
  selectGerman(){
    this.changeLanguage("de");
  }
  updateValue(language: Language, value: string){
    const translation = this.translations().find(t => t.language === language);
    if(translation){
      translation.updateValue(value);
    }else{
      this.translations.set([...this.translations(), new TranslationValue(language, value)]);
    }
  }
  changeLanguage(selectedLanguage: Language){
    this.isChangingLanguage = true;
    if(this.selectedLanguage() !== selectedLanguage) {
      this.selectedLanguage.set(selectedLanguage);
    }
    const translation = this.translations().find(t => t.language === selectedLanguage);
    if(translation){
      this.value.set(translation.value);
    }
    this.isChangingLanguage = false;
  }
}
