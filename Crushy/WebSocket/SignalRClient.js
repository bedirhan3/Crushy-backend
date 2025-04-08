// SignalR client for Crushy real-time messaging
// Bu dosyayı client-side projenizde kullanabilirsiniz

// SignalR bağlantısını kurmak için bu JavaScript kodunu kullanabilirsiniz
// npm install @microsoft/signalr

import * as signalR from "@microsoft/signalr";

class ChatClient {
    constructor(baseUrl, accessToken) {
        this.connection = null;
        this.baseUrl = baseUrl || "https://localhost:7218"; // API URL'inizi buraya girin
        this.accessToken = accessToken;
        this.callbacks = {
            onReceiveMessage: null,
            onMessageError: null,
            onUserStatusChanged: null,
            onMessageRead: null,
            onNewMessage: null,
            onReceiveNotification: null,
            onErrorNotification: null
        };
    }

    // SignalR bağlantısını başlat
    async startConnection(userId) {
        try {
            // Bağlantı zaten varsa ve aktifse bir şey yapmadan çık
            if (this.connection && this.connection.state === signalR.HubConnectionState.Connected) {
                return;
            }

            // Yeni bağlantı oluştur
            this.connection = new signalR.HubConnectionBuilder()
                .withUrl(`${this.baseUrl}/chathub`, {
                    accessTokenFactory: () => this.accessToken
                })
                .withAutomaticReconnect()
                .build();

            // Event listeners
            this.connection.on("ReceiveMessage", (message) => {
                if (this.callbacks.onReceiveMessage) {
                    this.callbacks.onReceiveMessage(message);
                }
            });

            this.connection.on("MessageError", (errorMessage) => {
                if (this.callbacks.onMessageError) {
                    this.callbacks.onMessageError(errorMessage);
                }
            });

            this.connection.on("UserStatusChanged", (statusData) => {
                if (this.callbacks.onUserStatusChanged) {
                    this.callbacks.onUserStatusChanged(statusData);
                }
            });

            this.connection.on("MessageRead", (messageId) => {
                if (this.callbacks.onMessageRead) {
                    this.callbacks.onMessageRead(messageId);
                }
            });

            this.connection.on("NewMessage", (messageData) => {
                if (this.callbacks.onNewMessage) {
                    this.callbacks.onNewMessage(messageData);
                }
            });

            this.connection.on("ReceiveNotification", (notification) => {
                if (this.callbacks.onReceiveNotification) {
                    this.callbacks.onReceiveNotification(notification);
                }
            });

            this.connection.on("ErrorNotification", (errorMessage) => {
                if (this.callbacks.onErrorNotification) {
                    this.callbacks.onErrorNotification(errorMessage);
                }
            });

            // Bağlantıyı başlat
            await this.connection.start();
            console.log("SignalR bağlantısı kuruldu.");

            // Kullanıcı için bağlantı kaydı yap
            if (userId) {
                await this.registerConnection(userId);
            }

            return true;
        } catch (error) {
            console.error("SignalR bağlantısı kurulamadı:", error);
            return false;
        }
    }

    // Bağlantıyı kullanıcıya kaydet
    async registerConnection(userId) {
        if (this.connection && this.connection.state === signalR.HubConnectionState.Connected) {
            await this.connection.invoke("RegisterConnection", userId);
            console.log(`Kullanıcı ID ${userId} için bağlantı kaydedildi.`);
        }
    }

    // Bağlantıyı sonlandır
    async stopConnection() {
        if (this.connection) {
            await this.connection.stop();
            console.log("SignalR bağlantısı sonlandırıldı.");
        }
    }

    // Mesaj gönder
    async sendMessage(senderId, receiverId, message) {
        if (this.connection && this.connection.state === signalR.HubConnectionState.Connected) {
            await this.connection.invoke("SendMessage", senderId, receiverId, message);
        } else {
            console.error("Mesaj gönderilemiyor: Bağlantı kurulmadı");
        }
    }

    // Mesajı okundu olarak işaretle
    async markMessageAsRead(messageId, userId) {
        if (this.connection && this.connection.state === signalR.HubConnectionState.Connected) {
            await this.connection.invoke("MarkMessageAsRead", messageId, userId);
        }
    }

    // Callback fonksiyonları ayarla
    on(event, callback) {
        if (this.callbacks.hasOwnProperty(event)) {
            this.callbacks[event] = callback;
        }
    }

    // Kullanıcının çevrimiçi durumunu kontrol et
    async isUserOnline(userId) {
        if (this.connection && this.connection.state === signalR.HubConnectionState.Connected) {
            return await this.connection.invoke("IsUserOnline", userId);
        }
        return false;
    }
}

export default ChatClient; 