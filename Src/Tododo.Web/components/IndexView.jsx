/** @jsx React.DOM */

var React = require("react");

var IndexView = React.createClass({
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
			<div className="jumbotron">
				<h1>Welcome to amazing Tododo!</h1>
			</div>
		);
	}
});


module.exports = IndexView;