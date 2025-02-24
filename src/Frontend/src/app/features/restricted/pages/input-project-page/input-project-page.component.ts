import {Component, inject} from '@angular/core';
import { NavigationBarFullComponent } from '../../../../shared/components/navigation-bar-full/navigation-bar-full.component';
import { ProjectInput } from '../../models/project-input';
import { InputProjectComponent } from '../../components/input-project/input-project.component';
import {ApiService} from "../../../../server/api/api.service";

@Component({
  selector: 'app-input-project-page',
  imports: [NavigationBarFullComponent, InputProjectComponent],
  templateUrl: './input-project-page.component.html',
  styleUrl: './input-project-page.component.scss'
})
export class InputProjectPageComponent {
  projectInput: ProjectInput = new ProjectInput();
  apiService = inject(ApiService)
  async sendRequest(){
    this.apiService.webApiEndpointsPostProject({
      project: await this.projectInput.buildRequest()
    }).subscribe(x => {

    });
  }

  onSave() {
    this.sendRequest();
  }
}
