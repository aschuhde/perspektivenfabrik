import { Component, inject, model, output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatIcon } from '@angular/material/icon';
import { RequirementPersonInput } from '../../models/requirement-person-input';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { FormsModule } from '@angular/forms';
import { EditRequirementPersonComponent } from '../../dialogs/edit-requirement-person/edit-requirement-person.component';

@Component({
  selector: 'app-input-requirement-person',
  imports: [FormsModule, MatIcon, MatAutocompleteModule],
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
