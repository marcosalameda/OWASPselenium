<template>
	<div
		class="form-flow"
		style="margin: 64px">
		<!--Basic Star Rating -->
		<q-row-container>
			<q-control-wrapper class="control-join-group">
				<h5>Basic usage (Default 5 stars)</h5>
				<q-rating />
			</q-control-wrapper>
		</q-row-container>

		<hr />

		<!-- 2nd variant -->
		<q-row-container>
			<q-control-wrapper class="control-join-group">
				<h5>Variable max rating (7 Stars)</h5>
				<q-rating :max-rating="7" />
			</q-control-wrapper>

			<!-- 10 stars -->
			<q-control-wrapper
				class="control-join-group"
				style="margin-left: 48px">
				<h5>Variable max rating (10 stars)</h5>
				<q-rating :max-rating="10" />
			</q-control-wrapper>
		</q-row-container>

		<hr />

		<!--Half Decimal Increment -->
		<q-row-container>
			<q-control-wrapper class="control-join-group">
				<h5>Half Icon Rating</h5>
				<q-rating
					:max-rating="7"
					:increment="0.5" />
			</q-control-wrapper>

			<!-- Decimal Increment by 0.25 -->
			<q-control-wrapper
				class="control-join-group"
				style="margin-left: 48px">
				<h5>Quarter Icon Rating (Decimal Increment by 0.25)</h5>
				<q-rating
					:max-rating="8"
					:increment="0.25" />
			</q-control-wrapper>

			<!-- Decimal Increment by 0.1 -->
			<q-control-wrapper
				class="control-join-group"
				style="margin-left: 48px">
				<h5>Decimal Increment by 0.1</h5>
				<q-rating
					:max-rating="5"
					:increment="0.1" />
			</q-control-wrapper>
		</q-row-container>

		<hr />

		<!-- Capture rating value on click  -->
		<q-row-container>
			<q-control-wrapper class="control-join-group">
				<h5>Capture Rating value on click</h5>
				<q-rating
					show-rating
					:max-rating="7"
					:increment="0.5"
					@update:rating="rating = $event" />
				<br />
				<div style="font-weight: bold">
					{{ currentRatingText }}
				</div>
			</q-control-wrapper>

			<!-- Hide Numeric value of Rating -->
			<q-control-wrapper
				class="control-join-group"
				style="margin-left: 48px">
				<h5>Show only iconography (Hide numeric value)</h5>
				<q-rating
					:max-rating="5"
					:show-rating="false" />
			</q-control-wrapper>
		</q-row-container>

		<hr />

		<!-- Change active color  -->
		<q-row-container>
			<q-control-wrapper class="control-join-group">
				<h5>Change active color</h5>
				<input
					type="color"
					v-model="activeColor" />
				<q-rating :active-color="activeColor" />
			</q-control-wrapper>

			<!-- Change inactive color -->
			<q-control-wrapper
				class="control-join-group"
				style="margin-left: 48px">
				<h5>Change inactive color</h5>
				<input
					type="color"
					v-model="inActiveColor" />
				<q-rating :inactive-color="inActiveColor" />
			</q-control-wrapper>
		</q-row-container>

		<hr />

		<!-- Change size  -->
		<q-row-container>
			<q-control-wrapper class="control-join-group">
				<h5>Star size 20</h5>
				<q-rating :shape-size="20" />
			</q-control-wrapper>

			<!-- Star size 30 -->
			<q-control-wrapper
				class="control-join-group"
				style="margin-left: 48px">
				<h5>Star size 30</h5>
				<q-rating :shape-size="30" />
			</q-control-wrapper>

			<!-- Star size 50 -->
			<q-control-wrapper
				class="control-join-group"
				style="margin-left: 48px">
				<h5>Star size 50</h5>
				<q-rating :shape-size="50" />
			</q-control-wrapper>
		</q-row-container>
	</div>
</template>

<script>
	import QRating from '@/components/rating/QRating.vue'

	export default {
		docsfile: './docs/rating/QRating.md',

		components: {
			QRating
		},

		inheritAttrs: false,

		data()
		{
			return {
				maxRatingLocal: 6,
				rating: 0,
				activeColor: '#0091EA',
				inActiveColor: '#BCD7E2'
			}
		},

		computed: {
			currentRatingText()
			{
				return this.rating ? `You have selected ${this.rating} stars!` : 'No rating selected.'
			}
		}
	}
</script>
