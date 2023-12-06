using System;

namespace Derivco.GameRoulette.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; } //Id of the bettor
        public DateTime? DateCreated { get; set; } //when did they place this bet?
        public string? CreatedBy { get; set; } //Name of the bettor
        public DateTime? DateModified { get; set; } //who modified the bet?
        public string? ModifiedBy { get; set; } //Has this bet been modified?
    }
}
