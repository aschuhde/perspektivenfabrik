import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GraphicDialogueAndDiscussionComponent } from './graphic-dialogue-and-discussion.component';

describe('GraphicDialogueAndDiscussionComponent', () => {
  let component: GraphicDialogueAndDiscussionComponent;
  let fixture: ComponentFixture<GraphicDialogueAndDiscussionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GraphicDialogueAndDiscussionComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GraphicDialogueAndDiscussionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
