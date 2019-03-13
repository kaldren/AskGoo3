import { Component, OnInit } from '@angular/core';
import { MessageService } from 'src/app/_services/message/message.service';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.less']
})
export class MessagesComponent implements OnInit {

  constructor(private messageService: MessageService) { }

  ngOnInit() {
    this.getAllMessagesByUserId();
  }

  getAllMessagesByUserId() {
    this.messageService.getAllMessagesByUserId().subscribe((data) => {
      console.log(data);
    })
  }

}
