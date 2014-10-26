module Conversation
open System;
open Events;

type Request = {
    Request:string
    TimeStamp : DateTime
}

type Response = {
    Message:string
    TimeStamp : DateTime
    ResponderId:int
}

type Reply = {
    Text:string
    TimeStamp: DateTime
}

type Message = 
    | Request of Request
    | Response of Response
    | Reply of Reply

type EstimatedResponseTime = 
    | None
    | Estimate of DateTime

type Conversation = 
    { Id:int
      mutable Version: int
      OwnerId:int
      Title:string
      Sender : int
      Messages: List<Message>
      Deadline: EstimatedResponseTime }

    member x.Raise(evt:ConversationEvent) = 
        x.Apply(evt:ConversationEvent)

    member x.Apply(evt:ConversationEvent) = 
        match evt with
        | Created(z)-> 
            let request = {
                Request = z.Message;
                TimeStamp=z.TimeStamp
            }
            let newConversation = {
                Id= 0;
                Version=1;
                OwnerId=z.SenderId;
                Title = z.Title;
                Sender = z.SenderId;
                Messages = Request(request)::[];
                Deadline = Estimate(z.TimeStamp.AddMinutes(30.0))
            }
            newConversation
        | Responded(z) ->
            let response = {    Message=z.Message; TimeStamp = z.TimeStamp;  ResponderId=z.SenderId}
            let newConversation = {
               Id= x.Id;
               Version=x.Version+1;
               OwnerId=x.OwnerId;
               Title = x.Title;
               Sender = x.Sender;
               Messages =  Response(response) :: x.Messages;
               Deadline = None
            }
            newConversation
        | Replied(z) ->
            let reply = { Text=z.Message; TimeStamp = z.TimeStamp; }
            let newConversation = {
               Id= x.Id;
               Version=x.Version+1;
               OwnerId=x.OwnerId;
               Title = x.Title;
               Sender = x.Sender;
               Messages =  Reply(reply) :: x.Messages;
               Deadline = Estimate(z.TimeStamp.AddMinutes(30.0))
            }
            newConversation           

 