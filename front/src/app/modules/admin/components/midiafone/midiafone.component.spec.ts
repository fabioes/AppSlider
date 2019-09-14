import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MidiafoneComponent } from './midiafone.component';

describe('MidiafoneFormComponent', () => {
  let component: MidiafoneComponent;
  let fixture: ComponentFixture<MidiafoneComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MidiafoneComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MidiafoneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
