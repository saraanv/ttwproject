import { Component } from '@angular/core';
import { PresenceDetailService } from 'src/app/shared/presence-detail.service';
import { NgForm } from "@angular/forms"
import { PresenceDetail } from 'src/app/shared/presence-detail.model';


@Component({
  selector: 'app-presence-detail-form',
  templateUrl: './presence-detail-form.component.html',
  styleUrls: ['./presence-detail-form.component.css']
})
export class PresenceDetailFormComponent {

  constructor( public service : PresenceDetailService){

  }

  onSubmit(form: NgForm )
  {
    this.service.formSubmitted = true 
    if(form.valid)
    {
      if(this.service.formData.presenceId==0)
      this.insertRecord(form)
    else 
    this.updateRecord(form)
    }
  }

    insertRecord(form:NgForm)
    {
      this.service.postPresenceDetail()
      .subscribe({
        next  : res =>{
      this.service.list = res as PresenceDetail[]
      this.service.resetForm (form)
    },
    error : err => {console.log(err)}
  })  
    }

    updateRecord(form:NgForm)
    {
      this.service.putPresenceDetail()
      .subscribe({
        next  : res =>{
      this.service.list = res as PresenceDetail[]
      this.service.resetForm (form)
    },
    error : err => {console.log(err)}
  })  

    }


}
