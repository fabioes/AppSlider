import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MidiafoneFormComponent } from './midiafone-form.component';

describe('MidiafoneFormComponent', () => {
  let component: MidiafoneFormComponent;
  let fixture: ComponentFixture<MidiafoneFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MidiafoneFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MidiafoneFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
