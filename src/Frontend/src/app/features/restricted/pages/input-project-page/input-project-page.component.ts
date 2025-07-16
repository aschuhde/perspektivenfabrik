import {Component, inject} from '@angular/core';
import { NavigationBarFullComponent } from '../../../../shared/components/navigation-bar-full/navigation-bar-full.component';
import { ProjectInput } from '../../models/project-input';
import { InputProjectComponent } from '../../components/input-project/input-project.component';
import {ApiService} from "../../../../server/api/api.service";
import { ProjectSaveContext } from '../../models/project-save-context';
import { RestrictedRouteNames } from '../../restricted-route-names';
import { catchError, of, throwError } from 'rxjs';
import { MatDialog } from "@angular/material/dialog";
import {TranslateService} from "@ngx-translate/core"
import {handleProjectSaveErrorAndGetDialogData} from "../../tools/error-handling";
import {Language} from "../../../../core/types/general-types";
import {Router} from "@angular/router";

@Component({
  selector: 'app-input-project-page',
  imports: [NavigationBarFullComponent, InputProjectComponent],
  templateUrl: './input-project-page.component.html',
  styleUrl: './input-project-page.component.scss'
})
export class InputProjectPageComponent {
  dialog = inject(MatDialog)
  translateService = inject(TranslateService)
  projectInput: ProjectInput = new ProjectInput(() => this.translateService.currentLang as Language);
  apiService = inject(ApiService)
  projectSaveContext: ProjectSaveContext = new ProjectSaveContext();
  router = inject(Router);
  
  constructor() { 
    this.projectSaveContext.hasChanges = true;
  }
  async sendRequest(){
    const request = await this.projectInput.buildRequest(this.translateService.currentLang as Language)
    this.apiService.webApiEndpointsPostProject({
      project: request
    }).pipe(catchError((err) => {
      handleProjectSaveErrorAndGetDialogData(err, this.dialog, this.translateService, request, "New Project");
    })).subscribe(x => {
      if((x as any).project){
        InputProjectComponent.IgnoreUnloadEvent = true;
        this.router.navigateByUrl(`${RestrictedRouteNames.UpdateProjectUrl((x as any).project.entityId)}${window.location.search}`).then();
      }
    });
  }

  async onSave() {
    await this.sendRequest();
  }
}
