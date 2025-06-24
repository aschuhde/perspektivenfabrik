import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RejectProjectDialogComponent } from './reject-project-dialog.component';

describe('RejectProjectDialogComponent', () => {
  let component: RejectProjectDialogComponent;
  let fixture: ComponentFixture<RejectProjectDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RejectProjectDialogComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RejectProjectDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
