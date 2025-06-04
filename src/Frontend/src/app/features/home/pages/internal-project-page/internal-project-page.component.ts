import {Component, inject} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {ApiService} from "../../../../server/api/api.service";
import {ApplicationModelsApiModelsApiProject} from "../../../../server/model/applicationModelsApiModelsApiProject";
import {ProjectDetailComponent} from "../../components/project-detail/project-detail.component";
import {
  NavigationBarFullComponent
} from "../../../../shared/components/navigation-bar-full/navigation-bar-full.component";
import {FooterComponent} from "../../components/footer/footer.component";

@Component({
  selector: 'app-internal-project-page',
    imports: [ProjectDetailComponent, NavigationBarFullComponent, FooterComponent],
  templateUrl: './internal-project-page.component.html',
  styleUrl: './internal-project-page.component.scss'
})
export class InternalProjectPageComponent {
  projectIdentifier: string = inject(ActivatedRoute).snapshot.paramMap.get("projectIdentifier") ?? "";
  apiService = inject(ApiService)
  project: ApplicationModelsApiModelsApiProject | null = null
  loadProject(){
    const projectResponse = this.apiService.webApiEndpointsGetInternalProject(this.projectIdentifier);

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
