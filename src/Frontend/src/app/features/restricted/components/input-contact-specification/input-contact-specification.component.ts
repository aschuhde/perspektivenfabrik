import { Component, inject, model, output } from '@angular/core';
import { ContactSpecificationType, ContactSpecification } from '../../models/contact-specification';
import { FormsModule } from '@angular/forms';
import { MatOption } from '@angular/material/core';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { MatIcon } from '@angular/material/icon';
import { MatInput } from '@angular/material/input';
import { MatSelect } from '@angular/material/select';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import {Language} from "../../../../core/types/general-types";
import {
    MatInputTranslationsComponent
} from "../../../../shared/components/mat-input-translations/mat-input-translations.component";
import {TranslationValue} from "../../../../shared/models/translation-value";

@Component({
  selector: 'app-input-contact-specification',
    imports: [MatIcon, MatFormField, MatSelect, MatLabel, MatOption, MatInput, FormsModule, TranslateModule, MatInputTranslationsComponent],
  templateUrl: './input-contact-specification.component.html',
  styleUrl: './input-contact-specification.component.scss'
})
export class InputContactSpecificationComponent {
  contactSpecification = model.required<ContactSpecification>();
  contactSpecificationIndex = model.required<number>();
  remove = output<ContactSpecification>();
    onChanged = output();
  translateService = inject(TranslateService)
  
  get contactSpecificationType(): ContactSpecificationType{
    return this.contactSpecification().contactSpecificationType;
  }
  set contactSpecificationType(value: ContactSpecificationType){
    this.contactSpecification().contactSpecificationType = value;
    this.onChanged.emit();
  }

  get currentLanguage(){
    return this.translateService.currentLang as Language;
  }
  
  get contactSpecificationTypeName(){
    if(this.currentLanguage === "it"){
      switch(this.contactSpecificationType){
        case "bankAccount":
          return "Conto bancario";
        case "paypalAccount":
          return "Conto Paypal";
        case "website":
          return "Sito web";
      }
    }
    switch(this.contactSpecificationType){
      case "bankAccount":
        return "Bankkonto";
      case "paypalAccount":
        return "Paypalkonto";    
      case "website":
        return "Website";    
    }
    return "";
  }  

  get bankAccountNumber(){
    return this.contactSpecificationIndex() + 1;
  }

  get bankAccountName(){
    return this.contactSpecification().bankAccountName;
  }
  set bankAccountName(value: string){
    this.contactSpecification().bankAccountName = value;
      this.onChanged.emit();
  }
  get bankAccountNameTranslations(){
    return this.contactSpecification().bankAccountNameTranslations;
  }
  set bankAccountNameTranslations(value: TranslationValue[]){
    this.contactSpecification().bankAccountNameTranslations = value;
    this.onChanged.emit();
  }

  get bankAccountIban(){
    return this.contactSpecification().bankAccountIban;
  }
  set bankAccountIban(value: string){
    this.contactSpecification().bankAccountIban = value;
      this.onChanged.emit();
  }

  get bankAccountBic(){
    return this.contactSpecification().bankAccountBic;
  }
  set bankAccountBic(value: string){
    this.contactSpecification().bankAccountBic = value;
      this.onChanged.emit();
  }

  get bankAccountReference(){
    return this.contactSpecification().bankAccountReference;
  }
  set bankAccountReference(value: string){
    this.contactSpecification().bankAccountReference = value;
      this.onChanged.emit();
  }
  get bankAccountReferenceTranslations(){
    return this.contactSpecification().bankAccountReferenceTranslations;
  }
  set bankAccountReferenceTranslations(value: TranslationValue[]){
    this.contactSpecification().bankAccountReferenceTranslations = value;
    this.onChanged.emit();
  }

  get paypalAddress(){
    return this.contactSpecification().paypalAddress;
  }
  set paypalAddress(value: string){
    this.contactSpecification().paypalAddress = value;
      this.onChanged.emit();
  }
  get paypalAddressTranslations(){
    return this.contactSpecification().paypalAddressTranslations;
  }
  set paypalAddressTranslations(value: TranslationValue[]){
    this.contactSpecification().paypalAddressTranslations = value;
    this.onChanged.emit();
  }

  get paypalMeAddress(){
    return this.contactSpecification().paypalMeAddress;
  }
  set paypalMeAddress(value: string){
    this.contactSpecification().paypalMeAddress = value;
      this.onChanged.emit();
  }
  get paypalMeAddressTranslations(){
    return this.contactSpecification().paypalMeAddressTranslations;
  }
  set paypalMeAddressTranslations(value: TranslationValue[]){
    this.contactSpecification().paypalMeAddressTranslations = value;
    this.onChanged.emit();
  }

  get website(){
    return this.contactSpecification().website;
  }
  set website(value: string){
    this.contactSpecification().website = value;
      this.onChanged.emit();
  }
  get websiteTranslations(){
    return this.contactSpecification().websiteTranslations;
  }
  set websiteTranslations(value: TranslationValue[]){
    this.contactSpecification().websiteTranslations = value;
    this.onChanged.emit();
  }

  removeClicked(){
    this.remove.emit(this.contactSpecification());
  }  
}
