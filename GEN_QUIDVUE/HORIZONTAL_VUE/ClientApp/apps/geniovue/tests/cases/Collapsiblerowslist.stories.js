import QCollapsiblerowslist from '@/components/rendering/QCollapsiblerowslist.vue'

export default {
	title: 'Views/CollapsibleRowsList',
	component: QCollapsiblerowslist,
	tags: ['autodocs'],
}

export const Collapsible = {
	args: {
		items:
			[
				{
					"id": 1,
					"text": "<h2>FAQ #1: What is our return policy?</h2><p>Our return policy allows you to return any product within 30 days of purchase, no questions asked. If you're not completely satisfied, simply fill out our <a href='/return-form'>return form</a> online, and we'll guide you through the process. Please make sure the item is in its original condition with all packaging and tags.</p><ul><li>Items damaged during shipping are eligible for a full refund or replacement.</li><li>Refunds will be processed within 5-7 business days after we receive your returned item.</li></ul>",
					"label": "FAQ #1: What is our return policy?"
				},
				{
					"id": 2,
					"text": "<h2>FAQ #2: How do I place an order?</h2><p>Placing an order is a breeze! Follow these steps:</p><ol><li>Browse our vast catalog and choose your desired items.</li><li>Add them to your shopping cart.</li><li>Click on the cart icon and proceed to checkout.</li></ol><p>During checkout, you can:</p><ul><li>Specify your preferred payment method, such as <em>Visa, MasterCard, or PayPal.</em></li><li>Enter any discount codes or coupons you may have.</li><li>Review your order details and confirm your purchase.</li></ul>",
					"label": "FAQ #2: How do I place an order?"
				},
				{
					"id": 3,
					"text": "<h2>FAQ #3: Can I track my order?</h2><p>Of course, you can! Once your order is <strong>shipped</strong>, you'll receive an email with a <a href='/tracking-link'>tracking link</a>. Click on the link to monitor the status of your delivery in real-time. If you created an account with us, you can also log in and check your order history to track shipments.</p>",
					"label": "FAQ #3: Can I track my order?"
				},
				{
					"id": 4,
					"text": "<h2>FAQ #4: What payment methods do you accept?</h2><p>We strive to make your shopping experience convenient. You can pay for your order using various methods, including:</p><ul><li><strong>Credit cards:</strong> We accept major credit cards like <em>Visa, MasterCard, American Express,</em> and more.</li><li><strong>PayPal:</strong> Use your PayPal account for secure payments.</li><li><strong>Apple Pay:</strong> If you're using an Apple device, enjoy the ease of Apple Pay during checkout.</li></ul><p>Choose the payment method that suits you best!</p>",
					"label": "FAQ #4: What payment methods do you accept?"
				},
				{
					"id": 5,
					"text": "<h2>FAQ #5: Do you offer international shipping?</h2><p>Absolutely! We're committed to serving customers worldwide. When you place your order, simply select your country from the dropdown menu during checkout. You'll then see available shipping options and costs specific to your location.</p><p>Keep in mind that international shipping times may vary depending on your destination.</p>",
					"label": "FAQ #5: Do you offer international shipping?"
				},
				{
					"id": 6,
					"text": "<h2>FAQ #6: How can I contact customer support?</h2><p>Our dedicated customer support team is here to assist you 24/7. You can reach us through various channels:</p><ul><li><strong>Live chat:</strong> Visit our website and chat with a live representative in real-time.</li><li><strong>Email:</strong> Drop us a message at <a href='mailto:support@company.com'>support@company.com</a> for prompt assistance.</li><li><strong>Phone:</strong> Give us a call anytime at <a href='tel:1-800-123-4567'>1-800-123-4567</a> for immediate help.</li></ul><p>We're here to make your experience exceptional!</p>",
					"label": "FAQ #6: How can I contact customer support?"
				}
			]
	}
}
