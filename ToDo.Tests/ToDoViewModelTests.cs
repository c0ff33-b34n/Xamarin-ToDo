using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ToDo;
using System.Linq;

namespace ToDo.Tests
{
    public class ToDoViewModelTests
    {
        [Fact]
        public void ViewModel_populates_items_correctly()
        {
            ToDoViewModel viewmodel = new ToDoViewModel();

            Assert.Equal(5, viewmodel.Items.Count);
        }

        [Fact]
        public void AddItemCommand_adds_new_item_to_the_list()
        {
            ToDoViewModel viewmodel = new ToDoViewModel();

            viewmodel.AddItemCommand.Execute(null);

            Assert.Equal(6, viewmodel.Items.Count);
            Assert.Equal("ToDo Item 6", viewmodel.Items.Last().Name);
        }

        [Fact]
        public void MarkAsCompletedCommand_marks_item_as_completed_and_puts_it_at_the_end_of_list()
        {
            ToDoViewModel viewmodel = new ToDoViewModel();

            viewmodel.MarkAsCompletedCommand.Execute(viewmodel.Items.First());

            Assert.True(viewmodel.Items.Last().Completed);
        }

        [Fact]
        public void MarkAsCompletedCommand_updates_progress()
        {
            ToDoViewModel viewmodel = new ToDoViewModel();

            viewmodel.MarkAsCompletedCommand.Execute(viewmodel.Items.First());

            Assert.Equal("Completed 1/5", viewmodel.CompletedHeader);
            Assert.Equal(0.2, viewmodel.CompletedProgress);
        }

    }
}
