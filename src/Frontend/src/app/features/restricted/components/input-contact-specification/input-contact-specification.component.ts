import { Component, model, output } from '@angular/core';
import { ContactSpecificationType, ContactSpecification } from '../../models/contact-specification';
import { FormsModule } from '@angular/forms';
import { MatOption } from '@angular/material/core';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { MatIcon } from '@angular/material/icon';
import { MatInput } from '@angular/material/input';
import { MatSelect } from '@angular/material/select';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-input-contact-specification',
  imports: [MatIcon, MatFormField, MatSelect, MatLabel, MatOption, MatInput, FormsModule, TranslateModule],
  templateUrl: './input-contact-specification.component.html',
  styleUrl: './input-contact-specification.component.scss'
})
export class InputContactSpecificationComponent {
  contactSpecification = model.required<ContactSpecification>();
  contactSpecificationIndex = model.required<number>();
  remove = output<ContactSpecification>();
    onChanged = output();
  
  get contactSpecificationType(): ContactSpecificationType{
    return this.contactSpecification().contactSpecificationType;
  }
  set contactSpecificationType(value: ContactSpecificationType){
    this.contactSpecification().contactSpecificationType = value;
    this.onChanged.emit();
  }

  get contactSpecificationTypeName(){
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

  get paypalAddress(){
    return this.contactSpecification().paypalAddress;
  }
  set paypalAddress(value: string){
    this.contactSpecification().paypalAddress = value;
      this.onChanged.emit();
  }

  get paypalMeAddress(){
    return this.contactSpecification().paypalMeAddress;
  }
  set paypalMeAddress(value: string){
    this.contactSpecification().paypalMeAddress = value;
      this.onChanged.emit();
  }

  get website(){
    return this.contactSpecification().website;
  }
  set website(value: string){
    this.contactSpecification().website = value;
      this.onChanged.emit();
  }

  removeClicked(){
    this.remove.emit(this.contactSpecification());
  }  
}
