<template>
	<!-- Main ChatBot container -->
	<div class="q-chatbot">
		<!-- Section: ChatBot Header -->
		<div class="c-sidebar__subtitle">
			<span>{{ texts.chatbotTitle }}</span>
		</div>
		<!-- Section: Messages Display -->
		<div
			class="q-chatbot__content"
			ref="messages">
			<!-- Loop through all sorted messages and display them -->
			<div
				v-for="message in sortedMessages"
				:key="message.id"
				:class="['q-chatbot__message-wrapper', { 'q-chatbot__message-wrapper_right': message.sender === 'user' }]">
				<!-- Display Bot Logo for bot's messages -->
				<img
					v-if="message.sender === 'bot'"
					:src="`${resourcesPath}chatbot.png`"
					alt=""
					class="q-chatbot__profile" />

				<!-- Message Container -->
				<div class="q-chatbot__message">
					<!-- Show typing animation when bot is typing and no message text is present -->
					<div
						v-if="isBotTyping && !message.text"
						class="q-chatbot__message-loading">
						<div></div>
						<div></div>
						<div></div>
					</div>

					<!-- Display Message Content -->
					<template v-else>
						<div
							class="q-chatbot__sender"
							v-if="message.text && message.sender === 'bot'">
							{{ getSenderName(message.sender) + ' ' + getConvertedTime(message.timestamp) }}
						</div>
						<div
							class="q-chatbot__timestamp"
							v-if="message.text && message.sender === 'user'">
							{{ getConvertedTime(message.timestamp) }}
						</div>
						<div
							class="q-chatbot__text"
							v-if="message.sender === 'bot'"
							v-html="message.text"></div>
						<div
							class="q-chatbot__text"
							v-else>
							{{ message.text }}
						</div>
					</template>
				</div>
			</div>
		</div>

		<!-- Section: Input for user to type and send messages -->
		<q-input-group size="block">
			<!-- Text input for typing messages -->
			<q-text-field
				v-model="messageWrite"
				class="q-chatbot__input"
				:placeholder="texts.placeholderMessage"
				@keyup.enter="sendMessage"
				@keydown="handleKey" />
			<!-- Send button appended to the text input -->
			<template #append>
				<q-button
					:title="texts.qButtonTitle"
					b-style="primary"
					class="q-chatbot__send"
					@click="sendMessage">
					<q-icon icon="send" />
				</q-button>
			</template>
		</q-input-group>
	</div>
</template>

<script>
	import { io } from 'socket.io-client'
	import axios from 'axios'

	import { validateTexts } from '@/mixins/genericFunctions.js'

	// The texts needed by the component.
	const DEFAULT_TEXTS = {
		chatbotTitle: 'ChatBot',
		qButtonTitle: 'Send message',
		initialMessage: 'I am ChatBot 👋, your personal AI assistant! How can I help you?',
		errorMessage: 'An error has occurred. Please contact the support team for more information.',
		placeholderMessage: 'Type your message here...'
	}

	export default {
		name: 'QChatBot',

		props: {
			/**
			 * Unique identifier of the application or system making use of the ChatBot.
			 */
			applicationName: {
				type: String,
				required: true
			},

			/**
			 * URL endpoint for making WebSocket connections to the chat server.
			 */
			socketServerEndpoint: {
				type: String,
				required: true
			},

			/**
			 * API endpoint for sending and receiving messages from the chat server.
			 */
			apiServerMessageEndpoint: {
				type: String,
				required: true
			},

			/**
			 * The path where the ChatBot and other related resources are located.
			 */
			resourcesPath: {
				type: String,
				required: true
			},

			/**
			 * The various textual elements or content displayed as part of the ChatBot interface.
			 */
			texts: {
				type: Object,
				validator: (value) => validateTexts(DEFAULT_TEXTS, value),
				default: () => DEFAULT_TEXTS
			}
		},

		expose: [],

		data() {
			return {
				socket: undefined, // Socket connection instance
				messages: [], // List of all messages (bot + user)
				userMessages: [], // List to store only user messages
				currentIndex: -1, // Index of the current message in userMessages
				nextMessageId: 1, // ID to be assigned to the next message
				isBotTyping: false, // Flag to check if bot is currently typing
				initialStatus: false, // Flag to check if initial message has been sent
				errorStatus: false, // Flag to check if an error has occurred
				messageWrite: '' // Text currently being typed by the user
			}
		},

		mounted() {
			this.initChat()
			this.scrollChatToBottom(this.$refs)
		},

		beforeUnmount() {
			// Clean up any remaining data and before the component is destroyed.
			this.messages = []
		},

		unmounted() {
			// Disconnect socket when component is unmounted.
			this.socket.disconnect()
		},

		computed: {
			/**
			 * Returns the messages sorted by timestamp. If two messages have the same timestamp,
			 * messages sent by the user will appear before messages sent by the bot.
			 */
			sortedMessages() {
				const messages = [...this.messages]

				return messages.sort((a, b) => {
					const diff = new Date(a.timestamp) - new Date(b.timestamp)
					return diff !== 0 ? diff : a.sender === 'user' ? -1 : 1
				})
			}
		},

		methods: {
			/**
			 * Initializes the socket connection for chat purposes and sets up event listeners.
			 *
			 * This method connects to the socket server endpoint specified in the class and sets
			 * up listeners for various socket events such as "connect", "message", "connect_error",
			 * "connect_failed", and "disconnect". It also handles the streaming effect for composing
			 * messages and manages the "bot typing" indicator.
			 */
			initChat() {
				this.socket = io(this.socketServerEndpoint, {
					reconnectionAttempts: 3,
					extraHeaders: {
						project: this.applicationName
					}
				})
				this.socket.on('connect', () => {
					if (this.messages.length === 0) this.sendInitialMessage()

					this.socket.on('message', (arg) => {
						if (arg !== '') {
							this.isBotTyping = true
							// Makes the streaming effect of composing the message
							this.messages.at(-1).text += arg['token']
						}
						// Deactivate thinking effect when receiving tokens
						if (arg['token'] === '') {
							this.isBotTyping = false
						}
						this.scrollChatToBottom(this.$refs)
					})
				})

				this.socket.on('connect_error', () => this.sendErrorMessage())
				this.socket.on('connect_failed', () => this.sendErrorMessage())
				this.socket.on('disconnect', () => this.sendErrorMessage())
			},

			/**
			 * Scrolls the chat messages container to the bottom.
			 *
			 * This method ensures that the latest messages are visible by scrolling the messages
			 * container to the bottom after a short delay.
			 * @param {Object} ref - A reference object containing the messages container.
			 */
			scrollChatToBottom(ref) {
				let messagesContainer = ref.messages
				setTimeout(() => (messagesContainer.scrollTop = messagesContainer.scrollHeight), 100)
			},

			/**
			 * Handles keyboard events for navigating through user messages.
			 *
			 * This method responds to the "ArrowUp" and "ArrowDown" keys to navigate through
			 * previously sent user messages. It updates the current message input based on the
			 * user's message history.
			 * @param {Event} event - The keyboard event triggered by user input.
			 */
			handleKey(event) {
				// event handler for keyboard
				if (event.key === 'ArrowUp') {
					if (this.currentIndex < this.userMessages.length - 1) {
						this.currentIndex += 1
						this.messageWrite = this.userMessages[this.currentIndex]
					} else if (this.currentIndex === this.userMessages.length - 1) {
						this.messageWrite = ''
					}
				} else if (event.key === 'ArrowDown') {
					if (this.currentIndex > 0) {
						this.currentIndex -= 1
						this.messageWrite = this.userMessages[this.currentIndex]
					} else if (this.currentIndex === 0) {
						this.messageWrite = ''
					}
				}
			},

			/**
			 * Sends an initial greeting message from the bot when the chat is initialized.
			 *
			 * This method pushes an initial message from the bot into the messages array with
			 * appropriate details such as ID, text, timestamp, and sender.
			 */
			sendInitialMessage() {
				if (!this.initialStatus) {
					this.messages.push({
						id: this.nextMessageId++,
						text: this.texts.initialMessage,
						timestamp: new Date(),
						sender: 'bot'
					})
				}
				this.initialStatus = true
			},

			/**
			 * Sends an error message when there's a socket connection issue.
			 *
			 * If an error hasn't already been flagged, this method pushes an error message
			 * from the bot into the messages array with details like ID, text, timestamp, and sender.
			 * It then sets the error status flag to true.
			 */
			sendErrorMessage() {
				if (!this.errorStatus) {
					this.messages.push({
						id: this.nextMessageId++,
						text: this.texts.errorMessage,
						timestamp: new Date(),
						sender: 'bot'
					})
				}
				this.errorStatus = true
			},

			/**
			 * Asynchronously sends the user's message and handles the bot's response.
			 * It sends a new message and awaits the bot's response.
			 * @returns {Promise<number>} Returns 0 if the message is empty or the bot is currently typing.
			 * @throws Will throw an error if there's an issue with sending the message to the API server.
			 */
			async sendMessage() {
				if (!this.messageWrite.replace(/\s/g, '').length || this.isBotTyping || !this.initialStatus || this.errorStatus) {
					return 0
				}

				this.isBotTyping = true
				let userMessage

				// If no message is being edited, send a new message
				userMessage = {
					id: this.nextMessageId++,
					text: this.messageWrite,
					timestamp: new Date(),
					sender: 'user'
				}

				this.userMessages.unshift(this.messageWrite)
				this.currentIndex = -1
				this.messages.push(userMessage)

				this.messageWrite = ''

				this.scrollChatToBottom(this.$refs)

				try {
					this.isBotTyping = true
					axios.post(
						this.apiServerMessageEndpoint,
						new URLSearchParams({
							message: userMessage.text,
							socketid: this.socket.id
						})
					)
					let botResponseText = ''
					var botMessage = {
						id: this.nextMessageId++,
						text: botResponseText, // Set the response from the function in the message text
						timestamp: new Date(),
						sender: 'bot'
					}
					// Store response in the message array
					this.messages.push(botMessage)
					// Clear user text input
					this.messageWrite = ''
				} catch (error) {
					this.isBotTyping = false
					this.sendErrorMessage()
				}
			},

			/**
			 * Returns the display name of the sender.
			 * @param {string} sender - The sender type, either "bot" or "user".
			 * @returns {string} Returns "ChatBot" if the sender is a bot, and "You" if the sender is a user.
			 */
			getSenderName(sender) {
				return sender === 'bot' ? 'ChatBot' : 'You'
			},

			/**
			 * Converts a Date object to a 12-hour format time string.
			 * @param {Date} date - The Date object to be converted.
			 * @returns {string} Returns the time in 12-hour format (e.g., "2:30 PM").
			 */
			getConvertedTime(date) {
				const hours = date.getHours()
				const minutes = date.getMinutes()
				const ampm = hours >= 12 ? 'PM' : 'AM'
				const twelveHour = hours % 12 || 12
				return `${twelveHour}:${minutes.toString().padStart(2, '0')} ${ampm}`
			}
		}
	}
</script>
