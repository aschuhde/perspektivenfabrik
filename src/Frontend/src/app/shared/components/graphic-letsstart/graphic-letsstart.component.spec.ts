import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GraphicLetsstartComponent } from './graphic-letsstart.component';

describe('GraphicLetsstartComponent', () => {
  let component: GraphicLetsstartComponent;
  let fixture: ComponentFixture<GraphicLetsstartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GraphicLetsstartComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GraphicLetsstartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
