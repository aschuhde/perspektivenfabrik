import { Component, inject, model, output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { MatOption, MatSelect } from '@angular/material/select';
import { MatInput } from '@angular/material/input';
import { EffortHoursType, RequirementPersonInput } from '../../models/requirement-person-input';
import { MessageDialogData } from '../../../../shared/models/message-dialog-data';
import { MessageDialogComponent } from '../../../../shared/dialogs/message-dialog/message-dialog.component';
import { SelectOption } from '../../../../shared/models/select-option';
import { MatAutocompleteModule, MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { FormsModule } from '@angular/forms';
import { MatChipInputEvent, MatChipsModule } from '@angular/material/chips';
import { COMMA, ENTER, TAB } from '@angular/cdk/keycodes';
import { MatSlideToggle } from '@angular/material/slide-toggle';
import { ProjectTimeInput } from '../../models/project-time-input';
import { InputProjectTimeComponent } from '../input-project-time/input-project-time.component';
import { LocationInput } from '../../models/location-input';
import { InputLocationComponent } from '../input-location/input-location.component';
import { EditRequirementPersonComponent } from '../../dialogs/edit-requirement-person/edit-requirement-person.component';

@Component({
  selector: 'app-input-requirement-person',
  imports: [FormsModule, MatFormField, MatLabel, MatInput, MatIcon, MatSelect, MatOption, MatButton, MatAutocompleteModule, MatChipsModule, MatSlideToggle, InputProjectTimeComponent, InputLocationComponent],
  templateUrl: './input-requirement-person.component.html',
  styleUrl: './input-requirement-person.component.scss'
})
export class InputRequirementPersonComponent {
  readonly dialog = inject(MatDialog);

  requirementPerson = model.required<RequirementPersonInput>();
  remove = output<RequirementPersonInput>();  
  requirementIndex = model.required<number>();

  get requirementNumber(){
    return this.requirementIndex() + 1;
  }

  get subText(){
    return this.requirementPerson().selectedSkills.map(x => x.text).join(", ");
  }

  openInDialog(){
    this.dialog.open(EditRequirementPersonComponent, {
      data: {
        requirementPerson: this.requirementPerson(),
        requirementIndex: this.requirementIndex()
      }
    });
  }
  removeClicked(){
    this.remove.emit(this.requirementPerson());
  }  

}
