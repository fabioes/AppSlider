import { Component, OnInit, ViewChild } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { GlobalService } from 'app/services/global/global.service';
import { AttendantService } from 'app/services/attendant/attendant.service';
import { QueueStatusService} from 'app/services/queue-status/queuestatus.service'
import { ToastrService } from 'ngx-toastr';
import { Table } from 'primeng/table';


@Component({
  selector: 'app-attendant-form',
  templateUrl: './attendant-form.component.html',
  styleUrls: ['./attendant-form.component.scss']
})
export class AttendantFormComponent implements OnInit {

  attendant: Model.App.AttendantContent;
  attendantForm: FormGroup;
  queueList: Array<Model.App.QueueStatusContent>;

  constructor(public activeModal: NgbActiveModal,
    private fb: FormBuilder,
    private globalService: GlobalService,
    private attendantService: AttendantService,
    private queueStatusService: QueueStatusService,
    private toastrService: ToastrService) { }

  ngOnInit() {
    this.queueStatusService.getAllQueueStatus().subscribe(res => {
      this.queueList = res;
    });

    this.attendantForm = this.fb.group({
      id: [this.attendant ? this.attendant.id : ''],
      name: [this.attendant ? this.attendant.name : '', Validators.required],
      userName: [this.attendant ? this.attendant.userName : '', Validators.required],
      queueStatus: [this.attendant ? this.attendant.queueStatus : '']      
    });

  }

  public saveAttendant() {

    if (this.attendantForm.invalid) return;

    this.attendant = this.attendantForm.value;

    if (this.attendant.id) {
      this.attendantService.updateAttendant(this.attendant).subscribe(res => this.callbackAction('alterado', res));
    }
    else {
      this.attendantService.createAttendant(this.attendant).subscribe(res => this.callbackAction('criado', res));
    }
  }
  

  public isFieldInvalid(field: string) {
    return this.globalService.isFieldInvalid(field, this.attendantForm);
  }


  public callbackAction(action, res){
  
    this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span> O atendente <b> ' + res.name + ' </b> foi ' + action + ' com sucesso.', '', {
      timeOut: 3500,
      closeButton: true,
      enableHtml: true,
      toastClass: "alert alert-success alert-with-icon",
      positionClass: 'toast-top-right'
    });

    this.activeModal.close(res);
  }



}
