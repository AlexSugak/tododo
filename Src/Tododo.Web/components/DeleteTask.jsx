/** @jsx React.DOM */

var React = require("react");
var deleteTask = require("../actions/deleteTask");

var DeleteTask = React.createClass({
	propTypes: {
		context: React.PropTypes.object.isRequired,
		taskId: React.PropTypes.string.isRequired
	},

	statics: {
	},

	getStateFromStores: function getStateFromStores() {
		return {};
	},

	getInitialState: function getInitialState() {
		return this.getStateFromStores();
	},

	_deleteClicked: function(event) {
		var data = {
			taskId: this.props.taskId
		};
		this.props.context.executeAction(deleteTask, data);
	},

	render: function render() {
		return (
			<button 
					type="button" 
					className="btn btn-default btn-lg pull-right"
					onClick={this._deleteClicked}>
				<span className="glyphicon glyphicon-remove" aria-hidden="true"></span> Delete
			</button>
		);
	}
});


module.exports = DeleteTask;