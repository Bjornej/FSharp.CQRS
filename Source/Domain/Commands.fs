module Commands
open System;

type CreateConversation = {
    SenderId:int
    Title: string
    Message:string
    TimeStamp:DateTime
}

type RespondToConversation = {
    SenderId:int
    Message:string
    TimeStamp:DateTime
}

type ReplyToConversation = {
    SenderId:int
    Message:string
    TimeStamp:DateTime
}

type ConversationCommand = 
    | CreateConversation
    | RespondToConversation
    | ReplyToConversation
