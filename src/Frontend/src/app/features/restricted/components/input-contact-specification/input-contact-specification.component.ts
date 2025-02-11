import { Component, model, output } from '@angular/core';
import { ContactSpecificationType, ContactSpecification } from '../../models/contact-specification';
import { FormsModule } from '@angular/forms';
import { MatOption } from '@angular/material/core';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { MatIcon } from '@angular/material/icon';
import { MatInput } from '@angular/material/input';
import { MatSelect } from '@angular/material/select';

@Component({
  selector: 'app-input-contact-specification',
  imports: [MatIcon, MatFormField, MatSelect, MatLabel, MatOption, MatInput, FormsModule],
  templateUrl: './input-contact-specification.component.html',
  styleUrl: './input-contact-specification.component.scss'
})
export class InputContactSpecificationComponent {
  contactSpecification = model.required<ContactSpecification>();
  contactSpecificationIndex = model.required<number>();
  remove = output<ContactSpecification>();
  
  get contactSpecificationType(): ContactSpecificationType{
    return this.contactSpecification().contactSpecificationType;
  }
  set contactSpecificationType(value: ContactSpecificationType){
    this.contactSpecification().contactSpecificationType = value;
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
  }

  get bankAccountIban(){
    return this.contactSpecification().bankAccountIban;
  }
  set bankAccountIban(value: string){
    this.contactSpecification().bankAccountIban = value;
  }

  get bankAccountBic(){
    return this.contactSpecification().bankAccountBic;
  }
  set bankAccountBic(value: string){
    this.contactSpecification().bankAccountBic = value;
  }

  get bankAccountReference(){
    return this.contactSpecification().bankAccountReference;
  }
  set bankAccountReference(value: string){
    this.contactSpecification().bankAccountReference = value;
  }

  get paypalAddress(){
    return this.contactSpecification().paypalAddress;
  }
  set paypalAddress(value: string){
    this.contactSpecification().paypalAddress = value;
  }

  get paypalMeAddress(){
    return this.contactSpecification().paypalMeAddress;
  }
  set paypalMeAddress(value: string){
    this.contactSpecification().paypalMeAddress = value;
  }

  get website(){
    return this.contactSpecification().website;
  }
  set website(value: string){
    this.contactSpecification().website = value;
  }

  removeClicked(){
    this.remove.emit(this.contactSpecification());
  }  
}
