/** @jsx React.DOM */

var React = require("react");

var TaskDetailsView = React.createClass({
	propTypes: {
	},
	statics: {
	},
	getInitialState: function getInitialState() {
		return {};
	},
	getStateFromStores: function getStateFromStores() {
		return {
		};
	},

	_onChange: function() {
		this.setState(this.getStateFromStores());
	},

	render: function render() {
		return (
			<div>
				<h1>Task Details View Here</h1>
			</div>
		);
	}
});


module.exports = TaskDetailsView;