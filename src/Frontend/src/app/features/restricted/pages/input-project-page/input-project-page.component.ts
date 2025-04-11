import {Component, inject} from '@angular/core';
import { NavigationBarFullComponent } from '../../../../shared/components/navigation-bar-full/navigation-bar-full.component';
import { ProjectInput } from '../../models/project-input';
import { InputProjectComponent } from '../../components/input-project/input-project.component';
import {ApiService} from "../../../../server/api/api.service";
import { ProjectSaveContext } from '../../models/project-save-context';
import { RestrictedRouteNames } from '../../restricted-route-names';

@Component({
  selector: 'app-input-project-page',
  imports: [NavigationBarFullComponent, InputProjectComponent],
  templateUrl: './input-project-page.component.html',
  styleUrl: './input-project-page.component.scss'
})
export class InputProjectPageComponent {
  projectInput: ProjectInput = new ProjectInput();
  apiService = inject(ApiService)
  projectSaveContext: ProjectSaveContext = new ProjectSaveContext();
  
  constructor() { 
    this.projectSaveContext.hasChanges = true;
  }
  async sendRequest(){
    this.apiService.webApiEndpointsPostProject({
      project: await this.projectInput.buildRequest()
    }).subscribe(x => {
      if((x as any).project){
        InputProjectComponent.IgnoreUnloadEvent = true;
        window.location.href = `${RestrictedRouteNames.UpdateProjectUrl((x as any).project.entityId)}${window.location.search}`;
      }
    });
  }

  async onSave() {
    await this.sendRequest();
  }
}
