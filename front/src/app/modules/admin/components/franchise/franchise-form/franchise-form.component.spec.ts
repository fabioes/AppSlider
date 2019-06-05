import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FranchiseFormComponent } from './franchise-form.component';

describe('BusinessFormComponent', () => {
  let component: FranchiseFormComponent;
  let fixture: ComponentFixture<FranchiseFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FranchiseFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FranchiseFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
