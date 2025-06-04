import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GraphicGoodLifeForAllComponent } from './graphic-good-life-for-all.component';

describe('GraphicGoodLifeForAllComponent', () => {
  let component: GraphicGoodLifeForAllComponent;
  let fixture: ComponentFixture<GraphicGoodLifeForAllComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GraphicGoodLifeForAllComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GraphicGoodLifeForAllComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
