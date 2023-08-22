import { Injectable } from '@angular/core';
//this is for talking to swagger http//
//it also shhoulld be imported  in app module
import { HttpClient} from "@angular/common/http" ;
import { environment } from 'src/environments/environment';
import { PresenceDetail } from './presence-detail.model';
import { NgForm } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class PresenceDetailService {

  url:string = environment.apiBaseURL + '/PresenceDetail'
  list : PresenceDetail[]= [] ;
  formData : PresenceDetail =  new PresenceDetail()
  formSubmitted : boolean = false ;
  constructor( private http : HttpClient )  { }

  refreshList(){
    this.http.get(this.url)
    .subscribe({
    next: res=>{
     this.list = res as PresenceDetail[]
    },
    error : err => {console}
  })
}

postPresenceDetail(){
  return this.http.post(this.url,this.formData)
}

putPresenceDetail(){
  return this.http.put(this.url + '/' + this.formData.presenceId , this.formData)
}

deletePresenceDetail (id : number) {
  return this.http.delete(this.url + '/' + id)
}

  resetForm(form:NgForm )
{
  form.form.reset()
  this.formData = new PresenceDetail()
  this.formSubmitted= false  ; 
}

}
