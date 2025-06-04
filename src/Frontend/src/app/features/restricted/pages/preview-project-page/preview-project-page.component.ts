import {Component, inject} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {ApiService} from "../../../../server/api/api.service";
import {ApplicationModelsApiModelsApiProject} from "../../../../server/model/applicationModelsApiModelsApiProject";
import {ProjectDetailComponent} from "../../../home/components/project-detail/project-detail.component";
import {
  NavigationBarFullComponent
} from "../../../../shared/components/navigation-bar-full/navigation-bar-full.component";
import {FooterComponent} from "../../../home/components/footer/footer.component";

@Component({
  selector: 'app-preview-project-page',
    imports: [ProjectDetailComponent, NavigationBarFullComponent, FooterComponent],
  templateUrl: './preview-project-page.component.html',
  styleUrl: './preview-project-page.component.scss'
})
export class PreviewProjectPageComponent {
  projectIdentifier: string = inject(ActivatedRoute).snapshot.paramMap.get("projectIdentifier") ?? "";
  apiService = inject(ApiService)
  project: ApplicationModelsApiModelsApiProject | null = null
  loadProject(){
    const projectResponse = this.apiService.webApiEndpointsGetUsersProject(this.projectIdentifier);

    projectResponse.subscribe(x => {
      if((x as any).project){
        this.project = (x as any).project;
      }
    });
  }

  ngOnInit(){
    this.loadProject();
  }
}
