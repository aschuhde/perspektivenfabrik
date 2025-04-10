import {Component, OnInit} from '@angular/core';
import { ApiService } from '../../../../server/api/api.service';

@Component({
    selector: 'app-test-restricted',
    imports: [],
    templateUrl: './test.component.html',
    styleUrl: './test.component.scss'
})
export class TestComponent implements OnInit{

  testText: string = "empty" 
  constructor(private apiService: ApiService) {
  }

  ngOnInit(): void {
        this.apiService.webApiEndpointsGetExample().subscribe((response) => {
          this.testText = "finished";
        })
    }
  
  
}
