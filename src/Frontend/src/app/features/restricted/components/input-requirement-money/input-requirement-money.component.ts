import { Component, inject, model, output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatIcon } from '@angular/material/icon';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { RequirementMoneyInput } from '../../models/requirement-money-input';
import { MessageDialogData } from '../../../../shared/models/message-dialog-data';
import { MessageDialogComponent } from '../../../../shared/dialogs/message-dialog/message-dialog.component';
import { COMMA, ENTER, TAB } from '@angular/cdk/keycodes';
import { ProjectTimeInput } from '../../models/project-time-input';
import { FormsModule } from '@angular/forms';
import { MatSlideToggle } from '@angular/material/slide-toggle';
import { InputProjectTimeComponent } from '../input-project-time/input-project-time.component';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-input-requirement-money',
    imports: [FormsModule, MatFormField, MatLabel, MatInput, MatIcon, MatSlideToggle, InputProjectTimeComponent, TranslateModule],
  templateUrl: './input-requirement-money.component.html',
  styleUrl: './input-requirement-money.component.scss'
})
export class InputRequirementMoneyComponent {
  readonly dialog = inject(MatDialog);
  readonly addOnBlur = false;
    readonly separatorKeysCodes = [ENTER, COMMA, TAB] as const;

  requirementMoney = model.required<RequirementMoneyInput>();
  remove = output<RequirementMoneyInput>();
  
  requirementIndex = model.required<number>();
    onChanged = output();

  get requirementNumber(){
    return this.requirementIndex() + 1;
  }

  get amountOfMoney(){
    return this.requirementMoney().amountOfMoney;
  }
  set amountOfMoney(value: string){
    this.requirementMoney().amountOfMoney = value;
      this.onChanged.emit();
  }
  
  get requirementTimeIsIdenticalToProjectTime(){
    return this.requirementMoney().requirementTimeIsIdenticalToProjectTime
  }
  set requirementTimeIsIdenticalToProjectTime(value: boolean){
    this.requirementMoney().requirementTimeIsIdenticalToProjectTime = value
      this.onChanged.emit();
  }
  get requirementTimes(){
    return this.requirementMoney().requirementTimes
  }
  set requirementTimes(value: ProjectTimeInput[]){
    this.requirementMoney().requirementTimes = value
  }


  readonly messageDialogs = {

  };
  removeClicked(){
    this.remove.emit(this.requirementMoney());
  }  

  showMessageDialog(dialogData: MessageDialogData) {
    this.dialog.open(MessageDialogComponent, {
      data: dialogData
    });
  }

  addRequirementTime(){
    this.requirementTimes.push(new ProjectTimeInput());
      this.onChanged.emit();
  }
  removeRequirementTime(requirementTime: ProjectTimeInput){
    const index = this.requirementTimes.indexOf(requirementTime);
    if(index < 0) return;
    this.requirementTimes.splice(index, 1);
      this.onChanged.emit();
  }

    onUpdated() {
        this.onChanged.emit();
    }
}
