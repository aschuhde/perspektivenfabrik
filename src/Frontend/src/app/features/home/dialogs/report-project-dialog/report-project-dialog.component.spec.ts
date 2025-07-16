import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportProjectDialogComponent } from './report-project-dialog.component';

describe('ReportProjectDialogComponent', () => {
  let component: ReportProjectDialogComponent;
  let fixture: ComponentFixture<ReportProjectDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReportProjectDialogComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReportProjectDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
