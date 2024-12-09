        /* Add Review
        [HttpPost]
        public ActionResult AddReview([FromBody] Review review)
        {
            if (review.Rating < 1 || review.Rating > 5)
                return BadRequest("Rating should be between 1 and 5.");
            
            _context.Reviews.Add(review);
            _context.SaveChanges();
            return Ok();
        }*/