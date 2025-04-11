import {inject, Injectable} from "@angular/core";
import {ApiService} from "../../server/api/api.service";
import {ApplicationModelsApiModelsApiTag} from "../../server/model/applicationModelsApiModelsApiTag";
import {ApplicationModelsApiModelsApiSkill} from "../../server/model/applicationModelsApiModelsApiSkill";
import { ApplicationModelsApiModelsApiMaterial } from "../../server/model/applicationModelsApiModelsApiMaterial";
import {catchError, of} from "rxjs";

@Injectable({
  providedIn: "root"
})
export class AutocompleteDataService {
  apiService = inject(ApiService)
  tags: ApplicationModelsApiModelsApiTag[] | undefined = undefined
  skills: ApplicationModelsApiModelsApiSkill[] | undefined = undefined
  materials: ApplicationModelsApiModelsApiMaterial[] | undefined = undefined
  private task: Promise<void> | undefined = undefined;
  async getTags(){
    if(!this.tags){
      await this.loadData();
    }
    return this.tags ?? [];
  }
  async getSkills(){
    if(!this.skills){
      await this.loadData();
    }
    return this.skills ?? [];
  }
  async getMaterials(){
    if(!this.materials){
      await this.loadData();
    }
    return this.materials ?? [];
  }
  
  async loadData(): Promise<void> {
    if(this.task){
      await this.task;
      return;
    }
    this.task = this.loadDataInternal();
    await this.task;
    this.task = undefined;
  }
  
  private async loadDataInternal(): Promise<void> {
    return new Promise<void>(resolve => {
      this.apiService.webApiEndpointsGetAutocompleteEntries().pipe(catchError(() => {
        return of(null);
      })).subscribe(x => {
        this.tags = x?.tags;
        this.skills = x?.skills;
        this.materials = x?.materials;
        resolve();
      });
    });
  }
}