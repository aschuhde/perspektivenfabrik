import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GraphicSustainableProjectsComponent } from './graphic-sustainable-projects.component';

describe('GraphicSustainableProjectsComponent', () => {
  let component: GraphicSustainableProjectsComponent;
  let fixture: ComponentFixture<GraphicSustainableProjectsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GraphicSustainableProjectsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GraphicSustainableProjectsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
