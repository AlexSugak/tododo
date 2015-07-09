/** @jsx React.DOM */

var React = require("react");
var ENTER_KEY_CODE = 13;
var addTask = require("../actions/addTask");
var updateNewTask = require("../actions/updateNewTask");

var StoreMixin = require("fluxible").StoreMixin;
var NewTaskStore = require("../stores/NewTaskStore");

var NewTask = React.createClass({
	mixins: [StoreMixin],
	propTypes: {
		context: React.PropTypes.object.isRequired
	},

	statics: {
		storeListeners: {
			_onChange: [NewTaskStore]
		}
	},

	_onChange: function() {
		this.setState(this.getStateFromStores());
	},
	

	getStateFromStores: function getStateFromStores() {
		return this.getStore(NewTaskStore).getItem();
	},

	getInitialState: function getInitialState() {
		return this.getStateFromStores();
	},

	_keyPressed : function(event) {
		if (event.keyCode === ENTER_KEY_CODE) {
			this._okClicked(event);
		}
	},

	_okClicked: function(event) {
		var item = {
			name: this.state.text,
		};
		this.props.context.executeAction(addTask,item);
	},

	_fieldChanged: function(event) {
		var data = {
			value: event.target.value
		};
		this.props.context.executeAction(updateNewTask, data);
	},

	render: function render() {
		return (
			<div className="form-group">
			    <label htmlFor="newTask">New task</label>
			    <input type="text"
			    	   className="form-control"
					   placeholder="task name"
					   name="newTask"
					   value={this.state.text}
					   onChange={this._fieldChanged}
					   onKeyDown={this._keyPressed}
					   />
			 </div>
		);
	}
});


module.exports = NewTask;