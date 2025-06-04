import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GraphicLetsgoComponent } from './graphic-letsgo.component';

describe('GraphicLetsgoComponent', () => {
  let component: GraphicLetsgoComponent;
  let fixture: ComponentFixture<GraphicLetsgoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GraphicLetsgoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GraphicLetsgoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
