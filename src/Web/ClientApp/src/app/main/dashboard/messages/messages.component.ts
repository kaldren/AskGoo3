import { Component, OnInit } from '@angular/core';
import { MessageService } from 'src/app/_services/message/message.service';
import { Message } from 'src/app/_models/message';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.less']
})
export class MessagesComponent implements OnInit {

  messages: any = []; // Todo: Use Message type

  constructor(private messageService: MessageService) { }

  ngOnInit() {
    this.getAllMessagesByUserId();
  }

  getAllMessagesByUserId() {
    this.messageService.getAllMessagesByUserId()
    .subscribe((data) => {
      this.messages = data;
    });
  }

}
