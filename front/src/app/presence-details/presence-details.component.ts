import { Component ,OnInit } from '@angular/core';
import { PresenceDetailService } from '../shared/presence-detail.service';
import { PresenceDetail } from '../shared/presence-detail.model';

@Component({
  selector: 'app-presence-details',
  templateUrl: './presence-details.component.html',
  styleUrls: ['./presence-details.component.css']
})
export class PresenceDetailsComponent implements OnInit
{
  constructor( public service : PresenceDetailService){

  }
  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(seletedRecord : PresenceDetail){

    this.service.formData =Object.assign({} ,seletedRecord ) ;
  }

  onDelete(id:number) {
    if (confirm('Sure To Delete The Record?'))
    this.service.deletePresenceDetail(id)
    .subscribe({
      next: res =>{
        this.service.list = res as PresenceDetail[]

      }
    })
  }
}
