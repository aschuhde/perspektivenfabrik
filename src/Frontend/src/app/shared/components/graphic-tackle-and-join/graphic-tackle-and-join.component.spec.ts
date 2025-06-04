import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GraphicTackleAndJoinComponent } from './graphic-tackle-and-join.component';

describe('GraphicTackleAndJoinComponent', () => {
  let component: GraphicTackleAndJoinComponent;
  let fixture: ComponentFixture<GraphicTackleAndJoinComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GraphicTackleAndJoinComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GraphicTackleAndJoinComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
