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

@Component({
  selector: 'app-input-requirement-money',
  imports: [FormsModule, MatFormField, MatLabel, MatInput, MatIcon, MatSlideToggle, InputProjectTimeComponent],
  templateUrl: './input-requirement-money.component.html',
  styleUrl: './input-requirement-money.component.scss'
})
export class InputRequirementMoneyComponent {
  readonly dialog = inject(MatDialog);
  readonly addOnBlur = false;
    readonly separatorKeysCodes = [ENTER, COMMA, TAB] as const;

  requirementMoney = model.required<RequirementMoneyInput>();
  remove = output<RequirementMoneyInput>();

  requirementTimeIsIdenticalToProjectTime: boolean = true;
  requirementTimes: ProjectTimeInput[] = [new ProjectTimeInput()];
  amountOfMoney: string = "";
  requirementIndex = model.required<number>();

  get requirementNumber(){
    return this.requirementIndex() + 1;
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
  }
  removeRequirementTime(requirementTime: ProjectTimeInput){
    const index = this.requirementTimes.indexOf(requirementTime);
    if(index < 0) return;
    this.requirementTimes.splice(index, 1);
  }
}
